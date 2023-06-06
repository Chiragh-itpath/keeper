<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('keeps', function (Blueprint $table) {
            $table->uuid('id')->primary();
            $table->string('title', 50);
            $table->timestamp('createdOn');
            $table->timestamp('updatedOn')->nullable();
            $table->boolean('isDeleted')->default(false);
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('keeps');
    }
};